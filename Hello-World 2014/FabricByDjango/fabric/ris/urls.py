from django.conf.urls import patterns, url

from ris import views

urlpatterns = patterns('',
	url(r'^study/$', views.index, name='study_index'),
	url(r'^study/register/$', views.register, name='study_register'),
	url(r'^study/register_form/$', views.register_form, name='study_register_form'),
	url(r'^study/register_form_update/$', views.register_form_update, name='study_register_form_update'),
	url(r'^study/generic_index/$', views.IndexView.as_view(), name='study_generic_index'),
	url(r'^study/(?P<study_id>\d+)/$', views.detail, name='study_detail'),
)