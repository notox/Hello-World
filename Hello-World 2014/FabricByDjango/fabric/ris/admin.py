from django.contrib import admin
from ris.models import Patient, Study, Department, VisitType, Clinician, Region, Mode, ExamRoom, Device, StudyStatus

class StudyInline(admin.StackedInline):
	model = Study
	extra = 1

class PatinetAdmin(admin.ModelAdmin):
	inlines = [StudyInline]
	list_display = ('name', 'birthday')
	list_filter = ['birthday']
	search_fields = ['name']
	
class StudyAdmin(admin.ModelAdmin):
	list_display = ('patient', 'study_date')
	
admin.site.register(Patient, PatinetAdmin)
admin.site.register(Study, StudyAdmin)
admin.site.register(Department)
admin.site.register(VisitType)
admin.site.register(Clinician)
admin.site.register(Region)
admin.site.register(Mode)
admin.site.register(ExamRoom)
admin.site.register(Device)
admin.site.register(StudyStatus)
