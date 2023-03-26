const dogButton = document.getElementById('dog-button');
const catButton = document.getElementById('cat-button');
const descriptionInput = document.getElementById('pet-description');
const generateButton = document.getElementById('generate-button');
const imageContainer = document.getElementById('pet-image-container');
const tryCnnButton = document.getElementById('try-cnn-button');


dogButton.addEventListener('click', selectPet);
catButton.addEventListener('click', selectPet);
generateButton.addEventListener('click', generatePet);
tryCnnButton.addEventListener('click', tryCnn);

let selectedPet = null;
let petImageUrl = null;

function selectPet(event) {
  selectedPet = event.target.id === 'dog-button' ? 'dog' : 'cat';
  // add "selected" class to clicked button and remove from other button
  event.target.classList.add('selected');
  const otherButton = event.target.id === 'dog-button' ? catButton : dogButton;
  otherButton.classList.remove('selected');
}

async function generatePet() {
  if (!selectedPet) {
    alert('Please select a pet first!');
    return;
  }
  const description = descriptionInput.value;
  const requestBody = { ImageDescription: selectedPet + ', ' + description };

  imageContainer.innerHTML = `<div class="spinner-border text-primary" role="status">
                              <span class="visually-hidden">Loading...</span>
                            </div>`;
  try {
    const response = await fetch('https://localhost:44339/v1/OpenAI/GenerateImage', {
      method: 'POST',
      mode: 'cors',
      body: JSON.stringify(requestBody),
      headers: { 'Content-Type': 'application/json' }
    });
    const responseData = await response.json();
    petImageUrl = responseData.ImageUrl;
    displayImage(petImageUrl);
    tryCnnButton.style.display = 'inline';
  } catch (error) {
    console.error(error);
    alert('An error occurred while generating the pet image.');
  }
}

function displayImage(url) {
  imageContainer.innerHTML = `<img src="${url}" alt="Pet Image">`;
}

function tryCnn() {
  // Get the selected pet
  const selectedPet = document.querySelector('.pet-button.selected').dataset.petType;

  // Get the pet image URL
  const petImage = document.querySelector('#pet-image-container img');
  const petImageUrl = petImage.src;

  // Set the values of the form fields
  document.querySelector('#selected-pet').value = selectedPet;
  document.querySelector('#image-path').value = petImageUrl;

  // Set the target of the form to the hidden iframe
  document.querySelector('#try-cnn-form').target = 'try-cnn-iframe';

  // Submit the form
  document.querySelector('#try-cnn-form').submit();

  // Show the response
  document.querySelector('#try-cnn-iframe').onload = function() {
    const responseText = document.querySelector('#try-cnn-iframe').contentDocument.body.innerText;
    document.querySelector('#try-cnn-button').insertAdjacentText('afterend', responseText);
  };
}
