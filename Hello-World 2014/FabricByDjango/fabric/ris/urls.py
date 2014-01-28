from django.conf.urls import patterns, url

from ris import views

urlpatterns = patterns('',
	url(r'^register/$', views.RegisterFormView.as_view(), name='register'),
	url(r'^register/(?P<study_id>\d+)/$', views.detail, name='register_detail'),
)