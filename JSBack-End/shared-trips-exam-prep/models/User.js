const {Schema, Types ,model} = require('mongoose');

const userSchema = new Schema({
    email: {type: String, required: true, unique: true},
    hashedPassword: {type: String, required: true },
    gender: {type: String, required: true},
    tripsHistory: {type: [Types.ObjectId], ref: 'Trip', default: []}
});

userSchema.index({email:1}, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema)

module.exports = User;