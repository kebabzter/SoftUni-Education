import { getMemeById, updateMeme } from '../api/memes.js';
import { html } from '../lib.js';


const editTemplate = (meme, onSubmit) => html`
<section @submit=${onSubmit} id="edit-meme">
            <form id="edit-form">
                <h1>Edit Meme</h1>
                <div class="container">
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
                    <label for="imageUrl">Image Url</label>
                    <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
                    <input type="submit" class="registerbtn button" value="Edit Meme">
                </div>
            </form>
        </section>`;

export async function editView(ctx){
    const meme = await getMemeById(ctx.params.id);
    ctx.render(editTemplate(meme, onSubmit));

    async function onSubmit(ev){
        ev.preventDefault();
        const formData = new FormData(ev.target);

        const meme = {
            title: formData.get('title'),
            description: formData.get('description'),
            imageUrl: formData.get('imageUrl')
        };
    
        if (meme.title == '' || meme.description == '' || meme.imageUrl == '') {
            return notify('All fields are required!')
        }
    
        await updateMeme(ctx.params.id, meme);
        ev.target.reset();
        ctx.page.redirect('/memes/' + ctx.params.id);
    }
}