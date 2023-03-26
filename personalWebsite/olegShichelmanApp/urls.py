
from django.urls import path
from . import views

urlpatterns = [
    path('', views.home, name='home'),
    path('index.html', views.home),
    path('openaicnn', views.openaicnn, name='openaicnn'),
    path('try_cnn/', views.try_cnn, name='try_cnn'),
]
