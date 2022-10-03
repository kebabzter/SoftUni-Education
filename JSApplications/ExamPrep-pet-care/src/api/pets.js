import { del, get, post, put } from './api.js';

export async function getAllPets(){
    return get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export async function createPet(pet){
    return post('/data/pets', pet)
}

export async function getPetById(id){
    return get('/data/pets/' + id);
}

export async function deletePet(id){
    return del('/data/pets/' + id);
}

export async function editPet(id, pet){
    return put('/data/pets/' + id, pet);
}