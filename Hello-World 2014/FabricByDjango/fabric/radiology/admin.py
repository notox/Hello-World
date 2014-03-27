from django.contrib import admin

from radiology.models import Mode, ExamRoom, Device, Item, ItemType

class ItemAdmin(admin.ModelAdmin):
	list_filter = ['item_type']
	
class ItemInline(admin.TabularInline):
	model = Item
	extra = 5	
	
class ItemTypeAdmin(admin.ModelAdmin):
	inlines = [ItemInline]

admin.site.register(Mode)
admin.site.register(ExamRoom)
admin.site.register(Device)
admin.site.register(Item, ItemAdmin)
admin.site.register(ItemType, ItemTypeAdmin)
