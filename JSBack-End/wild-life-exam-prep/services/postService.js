const { post } = require("../controllers/homeController");
const Post = require("../models/Post");
const User = require("../models/User");

async function getAll(){
    return Post.find({}).lean();
}

async function getById(id){
    return Post.findById(id).populate('author').lean();
}

async function create(post){
    return await Post.create(post);
}

async function update(id, post){
    
}

async function deleteById(id){
    await Post.findByIdAndRemove(id);
}

async function getAuthor(id){
    const post = Post.findById(id);
    const user = await User.findById(post.authorId)
    return {
        _id: user._id,
        firstName: user.firstName,
        lastName: user.lastName
    }
}

module.exports = {
    getAll,
    getById,
    create,
    update,
    deleteById,
    getAuthor
}