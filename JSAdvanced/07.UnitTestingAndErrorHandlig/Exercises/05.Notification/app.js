function notify(message) {
  let notification = document.getElementById("notification");
  notification.textContent = message; 
  notification.style.display = 'block';
  notification.addEventListener('click', getNotified);

  function getNotified(event) {
    event.target.style.display = 'none';
  }
}