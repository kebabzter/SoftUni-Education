import { del, get, post, put } from './api.js'

export async function getAllPosts(){
    return get('/data/posts?sortBy=_createdOn%20desc');
}

export async function createPost(_post){
    return post('/data/posts', _post)
}

export async function getPostById(id){
    return get('/data/posts/' + id);
}

export async function deletePost(id){
    return del('/data/posts/' + id);
}

export async function updatePost(id, post){
    return put('/data/posts/'+ id, post);
}

export async function postsByUserId(id){
    return get(`/data/posts?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}