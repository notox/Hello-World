from django.contrib import admin

from hospital.models import Department, VisitType, Clinician, Region

admin.site.register(Department)
admin.site.register(VisitType)
admin.site.register(Clinician)
admin.site.register(Region)
