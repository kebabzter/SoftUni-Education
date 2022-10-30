const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'lsjkfghsd234klfgb34w5jklgsfklgjh';

async function register(username, email, password){
    const existingWithUsername = await User.findOne({username}).collation({locale: 'en', strength:2})
    if (existingWithUsername){
        throw new Error('Username is taken');
    }
    const existingWithEmail = await User.findOne({email}).collation({locale: 'en', strength:2})
    if (existingWithEmail) {
        throw new Error('Email is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = await User.create({
        username,
        email,
        hashedPassword
    });

    const token = createSession(user._id, email);

    return token;
}

async function login(email, password){
    const user = await User.findOne({email: email}).collation({locale: 'en', strength:2});
    if(!user){
        throw new Error('Incorrect email or password');
    }

    const result = await bcrypt.compare(password, user.hashedPassword);

    if (result == false) {
        throw new Error('Incorrect email or password');
    }

    return createSession(user._id, user.email);
}

function createSession(_id, email){
    const payload= {
        _id,
        email: email,
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