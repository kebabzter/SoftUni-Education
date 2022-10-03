import { deleteOffer, getOfferById, getOfferForUserById, getTotalApplicationsCountForOffer, sendApplication } from '../api/offers.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (offer,isOwner,isLogged,onDelete,applications,showApplyButton,onApply) => html`
<section id="details">
  <div id="details-wrapper">
    <img id="details-img" src=${offer.imageUrl} alt="example1" />
    <p id="details-title">${offer.title}</p>
    <p id="details-category">
      Category: <span id="categories">${offer.category}</span>
    </p>
    <p id="details-salary">
      Salary: <span id="salary-number">${offer.salary}</span>
    </p>
    <div id="info-wrapper">
      <div id="details-description">
        <h4>Description</h4>
        <span>${offer.description}</span>
      </div>
      <div id="details-requirements">
        <h4>Requirements</h4>
        <span>${offer.requirements}</span>
      </div>
    </div>
    <p>Applications: <strong id="applications">${applications}</strong></p>
    <!--Edit and Delete are only for creator-->
    ${isLogged? html`
    <div id="action-buttons">
      ${isOwner? html`
      <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
      <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : ''}
      ${showApplyButton? html`
      <a @click=${onApply} href="javascript:void(0)" id="apply-btn">Apply</a>` : ''}
    </div>` : ''}
  </div>
</section>
`;

export async function detailsView(ctx) {
    const offerId = ctx.params.id;
    const userData = getUserData();
    // const offer = await getOfferById(offerId);
    const isLogged = userData? true: false;
    
    let [offer, applications, hasApplication] = await Promise.all([
      getOfferById(offerId),
      getTotalApplicationsCountForOffer(offerId),
      userData ? getOfferForUserById(userData.id, offerId) : 0
    ])
    
    const isOwner = userData?.id == offer._ownerId;
    let showApplyButton = isOwner == false && hasApplication == false && userData!=null;
  
    ctx.render(detailsTemplate(offer,isOwner,isLogged,onDelete, applications, showApplyButton, onApply));

    async function onDelete(){
      const choice = confirm('Are tou sure you want to delete this offer?');

      if (choice) {
          await deleteOffer(ctx.params.id);
          ctx.page.redirect('/dashboard');
      }
    }

    async function onApply(){
      await sendApplication(offerId)
      ctx.page.redirect('/details/' + offerId)
    }
};