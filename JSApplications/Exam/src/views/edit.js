import { editOffer, getOfferById } from '../api/offers.js';
import { html } from '../lib.js';


const editTemplate = (onSubmit, offer) => html`
<section id="edit">
  <div class="form">
    <h2>Edit Offer</h2>
    <form @submit=${onSubmit} class="edit-form">
      <input
        type="text"
        name="title"
        id="job-title"
        placeholder="Title"
        .value=${offer.title}
      />
      <input
        type="text"
        name="imageUrl"
        id="job-logo"
        placeholder="Company logo url"
        .value=${offer.imageUrl}
      />
      <input
        type="text"
        name="category"
        id="job-category"
        placeholder="Category"
        .value=${offer.category}
      />
      <textarea
        id="job-description"
        name="description"
        placeholder="Description"
        rows="4"
        cols="50"
        .value=${offer.description}
      ></textarea>
      <textarea
        id="job-requirements"
        name="requirements"
        placeholder="Requirements"
        rows="4"
        cols="50"
        .value=${offer.requirements}
      ></textarea>
      <input
        type="text"
        name="salary"
        id="job-salary"
        placeholder="Salary"
        value=${offer.salary}
      />
      <button type="submit">post</button>
    </form>
  </div>
</section>
`;

export async function editView(ctx) {
    const offerId = ctx.params.id;
    const offer = await getOfferById(offerId);
    ctx.render(editTemplate(onSubmit, offer));

    async function onSubmit(ev){
        ev.preventDefault();
        const formData = new FormData(ev.target);

        const offer = {
            title: formData.get('title').trim(),
            imageUrl: formData.get('imageUrl').trim(),
            category: formData.get('category').trim(),
            description: formData.get('description').trim(),
            requirements: formData.get('requirements').trim(),
            salary: formData.get('salary').trim(),
        }

        if(offer.title == '' || offer.imageUrl == ''|| offer.category == '' 
            || offer.description == '' || offer.requirements == '' || offer.salary == ''){
                return alert('All fields are required!')
        }

        await editOffer(offerId,offer);
        ev.target.reset();
        ctx.page.redirect('/dashboard');
    }
};