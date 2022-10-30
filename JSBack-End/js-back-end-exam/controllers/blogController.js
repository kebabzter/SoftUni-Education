const { hasUser } = require('../middlewares/guards');
const { getAll, create, getById, followBlog, deleteById, update } = require('../services/blogService');
const { parseError } = require('../util/parser');

const blogController = require('express').Router()

blogController.get('/', async (req, res) => {
    const blogs = await getAll();
    res.render('catalog', {
        title: 'Blogs Catalog',
        blogs
    })
})

blogController.get('/:id/details', async (req, res) => {
    const blog = await getById(req.params.id);

    if(req.user){
        if(blog.owner._id == req.user._id){
            blog.isOwner = true;
        }else if(blog.followList) {
            if(blog.followList.map(f => f._id.toString()).includes(req.user._id.toString())){
                blog.hasFollowed = true;
            }
            blog.followers = blog.followList.map(f => f.email).join(', ')
        }
        blog.isUser = true;
    }
    else{
        blog.isUser = false;
    }
    
    res.render('details', {
        title: 'Blog Details',
        blog: Object.assign(blog, {owner: blog.owner.email})
    })
})

blogController.get('/:id/follow', hasUser(),async (req, res) => {
    const blog = await getById(req.params.id);

    try {
        if (blog.owner._id == req.user._id) {
            blog.isOwner = true;
            throw new Error('Cannot follow your own blog')
        }
        if (blog.followList.map(f => f._id.toString()).includes(req.user._id.toString())) {
            blog.hasJoined = true;
            throw new Error('Cannot follow blog twice')
        }

        await followBlog(req.params.id, req.user._id);
        res.redirect(`/blogs/${req.params.id}/details`)
    } catch (error) {
        res.render('details', {
            title: 'Blog Details',
            blog: Object.assign(blog, {owner: blog.owner.email}),
            errors: parseError(error)
        })
    }
})

blogController.get('/create', hasUser(),(req, res) => {
    res.render('create', {
        title: 'Create Blog'
    })
})

blogController.post('/create', hasUser(),async (req, res) => {
    const blog = {
        title: req.body.title,
        image: req.body.image,
        content: req.body.content,
        category: req.body.category,
        owner: req.user._id,
    }
    try {
        if (Object.values(blog).some (v => !v)){
            throw new Error('All fields are required')
        }

        await create(blog);
        res.redirect('/blogs')
    } catch (error) {
        res.render('create',{
            title: 'Create Blog',
            body: blog,
            errors: parseError(error)
        })
    }
})

blogController.get('/:id/delete', hasUser(), async(req, res) => {
    const blog = await getById(req.params.id)

    if (blog.owner._id != req.user._id) {
        return res.redirect('/auth/login')
    }
    await deleteById(req.params.id);
    res.redirect('/blogs')
})

blogController.get('/:id/edit', hasUser(), async (req, res) => {
    const blog = await getById(req.params.id);

    if(blog.owner._id != req.user._id){
        return res.redirect('/auth/login')
    }

    res.render('edit', {
        title: 'Edit Blog',
        blog
    })
})

blogController.post('/:id/edit', hasUser(), async (req, res) => {
    const blog = await getById(req.params.id);

    if (blog.owner._id != req.user._id) {
        return res.redirect('/auth/login')
    }

    const edited = {
        title: req.body.title,
        image: req.body.image,
        content: req.body.content,
        category: req.body.category
    }

    try {
        if (Object.values(edited).some(v => !v)) {
            throw new Error('All fields are required');
        }

        await update(req.params.id, edited)
        res.redirect(`/blogs/${req.params.id}/details`)
    } catch (error) {
        res.render('edit', {
            title: 'Edit Blog',
            blog: Object.assign(edited, { _id: req.params.id}),
            errors: parseError(error)
        })
    }
})

module.exports = blogController;