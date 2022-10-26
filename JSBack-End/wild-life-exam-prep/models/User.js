const {Schema, model, Types} = require('mongoose');

const userSchema = new Schema({
    email: {type: String, required: true, unique: true},
    firstName: {type: String, required:true},
    lastName: {type: String, required:true},
    hashedPassword: {type: String, required: true },
    userPosts: {type: [Types.ObjectId], ref: 'Post', default: []}
});

userSchema.index({email:1}, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema)

module.exports = User;