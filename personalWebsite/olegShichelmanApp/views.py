import os
from django.shortcuts import render
import requests
from django.http import JsonResponse
import numpy as np
import tensorflow as tf
from PIL import Image
from keras.models import load_model

def home(request):
    return render(request, 'index.html')

def openaicnn(request):
    return render(request, 'openaicnn.html')

def try_cnn(request):
    # temporary
    return JsonResponse({'error': 'Not yet supported.'}, status=400)
    # Get the image path from the POST request
    image_path = request.POST.get('image_path')
    if not image_path:
        return JsonResponse({'error': 'Image path is missing.'}, status=400)

    # Load the model from the h5 file
    model_path = os.path.join(os.path.dirname(__file__), 'model.h5')

    try:
        model = load_model(model_path)
    except:
        return JsonResponse({'error': 'Model file not found.'}, status=500)

    # Load the image and resize it to the input size of the model
    img = Image.open(image_path).resize((150, 150))
    img_array = np.array(img) / 255.0
    img_array = np.expand_dims(img_array, axis=0)

    # Perform the prediction using the model
    prediction = model.predict(img_array)[0]
    if prediction >= 0.5:
        result = 'dog'
    else:
        result = 'cat'

    # Get the selected pet from the POST request
    selected_pet = request.POST.get('selected_pet')
    if not selected_pet:
        return JsonResponse({'error': 'Selected pet is missing.'}, status=400)

    # Compare the prediction with the selected pet and return the result
    if result == selected_pet:
        return JsonResponse({'result': 'success'})
    else:
        return JsonResponse({'result': 'failed'})
