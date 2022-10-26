const { register, login } = require('../services/userService');
const { parseError } = require('../util/parser');

const authController = require('express').Router()


authController.get('/register', (req, res) => {
    res.render('register', {
        title: 'Register Page'
    });
});

authController.post('/register', async (req, res) => {
    try {
        if(req.body.email == '' || req.body.password == '' || req.body.firstName == '' || req.body.lastName == '' || req.body.repass == ''){
            throw new Error('All fields are required');
        }
        if (req.body.password != req.body.repass) {
            throw new Error('Passwords don\'t match')
        }
        const token = await register(req.body.email, req.body.password, req.body.firstName, req.body.lastName);

        res.cookie('token', token)
        res.redirect('/');
    } catch (error) {
        const errors = parseError(error);
        res.render('register', {
            title: 'Register Page',
            errors,
            body: {
                email: req.body.email,
                firstName: req.body.firstName,
                lastName: req.body.lastName,
            }
        });

    }
});

authController.get('/login', (req, res) => {
    res.render('login', {
        title: 'Login Page'
    });
});


authController.post('/login', async (req, res) => {
    try {
        const token = await login(req.body.email, req.body.password);

        res.cookie('token', token)
        res.redirect('/');
    } catch (error) {
        const errors = parseError(error);
        
        res.render('login', {
            title: 'Login Page',
            errors,
            body: {
                email: req.body.email
            }
        })
    }
})

authController.get('/logout', (req, res) => {
    res.clearCookie('token');
    res.redirect('/');
})


module.exports = authController;