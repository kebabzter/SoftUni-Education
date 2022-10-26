const { getAll, create, deleteById, getById,  getAuthor } = require('../services/postService');
const { parseError } = require('../util/parser');

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

    console.log(post.author);
    res.render('details', {
        title: 'Post Details',
        post
    })
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