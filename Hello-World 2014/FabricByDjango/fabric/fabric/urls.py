from django.conf.urls import patterns, include, url

from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'fabric.views.home', name='home'),
    # url(r'^blog/', include('blog.urls')),
	url(r'^ris/', include('ris.urls', namespace="ris")),
    url(r'^admin/', include(admin.site.urls)),
)
