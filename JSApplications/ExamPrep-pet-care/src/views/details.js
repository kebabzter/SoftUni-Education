import { getPetById, deletePet } from '../api/pets.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (pet,isLogged, isOwner, onDelete) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${pet.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>
            ${isLogged? html`
            <div class="actionBtn">
                ${isOwner? html`
                <a href="/edit/${pet._id}" class="edit">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>` : html`<a href="#" class="donate">Donate</a>`}
                
            </div>` : ''}
        </div>
    </div>
</section>`;

export async function detailsView(ctx) {
    const petId = ctx.params.id;
    const userData = getUserData();
    const pet = await getPetById(petId);
    const isLogged = userData? true: false;
    const isOwner = userData?.id == pet._ownerId;

    ctx.render(detailsTemplate(pet,isLogged,isOwner,onDelete));

    async function onDelete(){
        const choice = confirm('Are tou sure you want to delete this pet?');

        if (choice) {
            await deletePet(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
};