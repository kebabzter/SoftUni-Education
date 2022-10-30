const Blog = require("../models/Blog");
const User = require("../models/User");

async function getAll(){
    return Blog.find({}).lean();
}

async function getLastThree(){
    const blogs = await Blog.find({}).lean();
    return blogs.slice(-3);
}

async function getById(id){
    return Blog.findById(id).populate('owner').populate('followList').lean();
}

async function create(blog){
    return await Blog.create(blog)
}

async function followBlog(blogId, userId){
    const blog = await Blog.findById(blogId);

    blog.followList.push(userId);

    await blog.save();
}

async function getByOwnerId(userId){
    return Blog.find({owner: userId}).lean();
}

async function getFollowedByUser(userId){
    return Blog.find({followList: userId}).lean();
}

async function update(id, blog){
    const existing = await Blog.findById(id);

    existing.title = blog.title;
    existing.image = blog.image;
    existing.content = blog.content;
    existing.category = blog.category;

    await existing.save();
}

async function deleteById(id){
    await Blog.findByIdAndRemove(id)
}

module.exports = {
    getAll,
    getById,
    create,
    update,
    deleteById,
    followBlog,
    getLastThree,
    getByOwnerId,
    getFollowedByUser
}