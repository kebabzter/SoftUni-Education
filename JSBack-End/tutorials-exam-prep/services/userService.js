const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'lsjkfghsd234klfgb34w5jklgsfklgjh';

async function register(username, password){
    const existing = await User.findOne({username}).collation({locale: 'en', strength:2})
    if (existing){
        throw new Error('Username is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = await User.create({
        username,
        hashedPassword
    });

    const token = createSession(user._id, user.username);

    return token;
}

async function login(username, password){
    const user = await User.findOne({username}).collation({locale: 'en', strength:2});
    if(!user){
        throw new Error('Incorrect username or password');
    }

    const result = await bcrypt.compare(password, user.hashedPassword);

    if (result == false) {
        throw new Error('Incorrect username or password');
    }

    return createSession(user._id, user.username);
}

function createSession(_id, username){
    const payload= {
        _id,
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