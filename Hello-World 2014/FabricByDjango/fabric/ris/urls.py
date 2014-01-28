from django.conf.urls import patterns, url

from ris import views

urlpatterns = patterns('',
	url(r'^study/register_form/$', views.RegisterFormView.as_view(), name='study_register_form'),
	url(r'^study/(?P<study_id>\d+)/$', views.detail, name='study_detail'),
)