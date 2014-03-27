from django.db import models
from django.utils.translation import ugettext_lazy as _

class Mode(models.Model):
	name = models.CharField(_('Mode'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Mode')
		verbose_name_plural = _('Mode')
		
class ItemType(models.Model):
	name = models.CharField(_('ItemType'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	mode = models.ForeignKey(Mode, verbose_name=_('Mode'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Item Type')
		verbose_name_plural = _('Item Type')
		
class Item(models.Model):
	name = models.CharField(_('Item'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	item_type = models.ForeignKey(ItemType, verbose_name=_('Item Type'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Item')
		verbose_name_plural = _('Item')
		
class ExamRoom(models.Model):
	name = models.CharField(_('Exam Room'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	mode = models.ForeignKey(Mode, verbose_name=_('Mode'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Exam Room')
		verbose_name_plural = _('Exam Room')
		
class Device(models.Model):
	name = models.CharField(_('Device'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	exam_room = models.ForeignKey(ExamRoom, verbose_name=_('Exam Room'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Device')
		verbose_name_plural = _('Device')
