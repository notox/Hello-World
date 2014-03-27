from django.contrib import admin
from ris.models import Patient, Study, StudyStatus

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
admin.site.register(StudyStatus)