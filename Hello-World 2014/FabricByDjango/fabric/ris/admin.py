from django.contrib import admin
from ris.models import Patient, Study, Department, VisitType, Clinician, Region, Mode, ExamRoom, Device, StudyStatus, Item, ItemType

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
	
class ItemAdmin(admin.ModelAdmin):
	list_filter = ['item_type']
	
class ItemInline(admin.TabularInline):
	model = Item
	extra = 5	
	
class ItemTypeAdmin(admin.ModelAdmin):
	inlines = [ItemInline]

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
admin.site.register(Item, ItemAdmin)
admin.site.register(ItemType, ItemTypeAdmin)
