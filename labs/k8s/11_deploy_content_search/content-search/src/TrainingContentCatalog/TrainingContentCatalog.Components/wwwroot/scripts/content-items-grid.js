
function ignoreEnterKey(e) {
  if (e.keyCode == 13) {
      e.preventDefault();
      e.stopImmediatePropagation();
      return false;
  }
}

window.preventGridFormSubmit = function() {
  const formElement = document.querySelector('form.e-gridform');
  if (formElement) {
    formElement.addEventListener("keydown", ignoreEnterKey, true);
  }
};