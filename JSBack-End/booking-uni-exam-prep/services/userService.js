const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'lsjkfghsd234klfgb34w5jklgsfklgjh';

async function register(email, username, password){
    const existingUsername = await User.findOne({username}).collation({locale: 'en', strength:2})
    if (existingUsername){
        throw new Error('Username is taken');
    }
    const existingEmail = await User.findOne({email}).collation({locale: 'en', strength:2})
    if (existingEmail){
        throw new Error('Email is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = await User.create({
        email,
        username,
        hashedPassword
    });

    // TODO see assignment if registration creates user session
    const token = createSession(user._id, user.username);

    return token;
}

async function login(email, password){
    const user = await User.findOne({ email }).collation({locale: 'en', strength:2});
    if(!user){
        throw new Error('Incorrect email or password');
    }

    const result = await bcrypt.compare(password, user.hashedPassword);

    if (result == false) {
        throw new Error('Incorrect email or password');
    }

    return createSession(user._id, user.username);
}

function createSession(_id, email, username){
    const payload= {
        _id,
        email,
        username: username
    }

    return jwt.sign(payload, JWT_SECRET);
}

function verifyToken(token){
    return jwt.verify(token, JWT_SECRET)
}

module.exports = {
    register,
    login,
    verifyToken
}