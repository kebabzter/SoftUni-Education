const {model, Types, Schema} = require('mongoose');

const URL_PATTERN = /^https?:\/\/.+$/i

const blogSchema = new Schema({
    title: {type: String, required: true, minlength: [5, 'Title must be at least 5 characters long'], maxlength: [50, 'Title mustn\'t be more than 50 characters']},
    image: {type : String, required: true, validate: {
        validator: (value) => URL_PATTERN.test(value),
        message: 'Image URL is not valid'
    }},
    content: {type: String, required: true, minlength: [10, 'Content must be at least 10 characters long']},
    category: {type: String, required: true, minlength: [3, 'Category must be at least 3 characters long']},
    followList: {type: [Types.ObjectId], ref: 'User', default: []},
    owner: {type: Types.ObjectId, ref: 'User', required: true}
})

const Blog = model('Blog', blogSchema)

module.exports = Blog;