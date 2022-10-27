const { getAll, create, deleteById, getById,  getAuthor, downvote, upvote, getVotersAndPost, update } = require('../services/postService');
const { parseError } = require('../util/parser');
const { post } = require('./homeController');

const postsController = require('express').Router();

postsController.get('/all', async (req, res) => {
    const posts = await getAll();

    res.render('all-posts', {
        title: 'All posts',
        posts
    })
})

postsController.get('/:id/details', async (req, res) => {
    const post = await getById(req.params.id);

    if (req.user) {
        post.isUser = true;
    }

    if (post.votes.map(v => v.toString()).includes(req.user._id.toString())) {
        post.hasVoted = true;
    }

    if(post.author._id == req.user._id){
        post.isOwner = true;
    }

    const postWithVoters = await getVotersAndPost(req.params.id)
    post.voters = postWithVoters.votes.map(v => v.email).join(', ')

    res.render('details', {
        title: 'Post Details',
        post
    })
})

postsController.get('/:id/upvote', async (req, res) => {
    const post = await getById(req.params.id);
    await upvote(req.params.id, req.user._id);

    res.redirect(`/posts/${req.params.id}/details`)
})

postsController.get('/:id/downvote', async (req, res) => {
    const post = await getById(req.params.id);
    await downvote(req.params.id, req.user._id);

    res.redirect(`/posts/${req.params.id}/details`)
})

postsController.get('/:id/edit', async (req, res) => {
    const post = await getById(req.params.id);

    if (post.author._id != req.user._id) {
        return res.redirect('/auth/login')
    }

    res.render('edit',{
        title: 'Edit Post',
        post
    })
})

postsController.post('/:id/edit', async (req, res) => {
    const post = await getById(req.params.id)

    if (post.author._id != req.user._id) {
        return res.redirect('/auth/login')
    }
    
    const edited = {
        title: req.body.title,
        keyword: req.body.keyword,
        location: req.body.location,
        dateOfCreation: req.body.dateOfCreation,
        imageUrl: req.body.imageUrl,
        description: req.body.description,
    }

    try {
        if (Object.values(post).some(v => !v)) {
            throw new Error('All fields are required');
        }

        await update(req.params.id, edited);
        res.redirect(`/posts/${req.params.id}/details`)
    } catch (error) {
        res.render('edit', {
            title: 'Edit Post',
            post,
            errors: parseError(error)
        })
    }   
})

postsController.get('/create', (req, res) => {
    res.render('create', {
        title: 'Create Post'
    })
})

postsController.post('/create', async (req, res) => {
    const post = {
        title: req.body.title,
        keyword: req.body.keyword,
        location: req.body.location,
        dateOfCreation: req.body.dateOfCreation,
        imageUrl: req.body.imageUrl,
        description: req.body.description,
        author: req.user._id
    }

    try {
        if (Object.values(post).some(v => !v)) {
            throw new Error('All fields are required');
        }

        await create(post);
        res.redirect('/posts/all')
    } catch (error) {
        res.render('create', {
            title: 'Create Post',
            post,
            errors: parseError(error)
        })
    }
})

postsController.get('/:id/delete', async (req, res) =>{
    await deleteById(req.params.id);
    res.redirect('/posts/all')
})

module.exports = postsController;