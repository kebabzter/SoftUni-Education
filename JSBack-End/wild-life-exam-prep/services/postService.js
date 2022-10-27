const Post = require("../models/Post");
const User = require("../models/User");

async function getAll(){
    return Post.find({}).lean();
}

async function getById(id){
    return Post.findById(id).populate('author').lean();
}

async function getVotersAndPost(id){
    return Post.findById(id).populate('votes').lean();
}

async function create(post){
    return await Post.create(post);
}

async function upvote(postId, userId){
    const post = await Post.findById(postId)
    post.votes.push(userId);
    post.rating++;

    await post.save();
}

async function downvote(postId, userId){
    const post = await Post.findById(postId)
    post.votes.push(userId);
    post.rating--;

    await post.save();
}

async function update(id, post){
    const existing = await Post.findById(id);

    existing.title = post.title;
    existing.keyword = post.keyword;
    existing.location = post.location;
    existing.dateOfCreation = post.dateOfCreation;
    existing.imageUrl = post.imageUrl;
    existing.description = post.description;

    await existing.save();
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
    getAuthor,
    upvote,
    downvote,
    getVotersAndPost
}