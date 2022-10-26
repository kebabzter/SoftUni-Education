const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'lsjkfghsd234klfgb34w5jklgsfklgjh';

async function register(email, password, firstName, lastName){
    const existing = await User.findOne({email: email}).collation({locale: 'en', strength:2})
    if (existing){
        throw new Error('Email is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = await User.create({
        email: email,
        firstName: firstName,
        lastName: lastName,
        hashedPassword
    });

    const token = createSession(user._id, user.email);

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
        email: email
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