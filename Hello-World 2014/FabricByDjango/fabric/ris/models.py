from django.db import models
from django.utils.translation import ugettext_lazy as _

class Department(models.Model):
	name = models.CharField(_('Department'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Department')
		verbose_name_plural = _('Department')

class VisitType(models.Model):
	name = models.CharField(_('VisitType'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Visit Type')
		verbose_name_plural = _('Visit Type')
		
class Clinician(models.Model):
	name = models.CharField(_('Clinician'), max_length=30)
	department = models.ForeignKey(Department, verbose_name=_('Department'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Clinician')
		verbose_name_plural = _('Clinician')

class Region(models.Model):
	name = models.CharField(_('Region'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	department = models.ForeignKey(Department, verbose_name=_('Department'))
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Region')
		verbose_name_plural = _('Region')

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
		
class Patient(models.Model):
	name = models.CharField(_('Name'), max_length=32)
	birthday = models.DateTimeField(_('Birthday'), 'birthday')
	
	def __unicode__(self):
		return self.name
	
	class Meta:
		verbose_name = _('Patient')
		verbose_name_plural = _('Patient')
	
class StudyStatus(models.Model):
	name = models.CharField(_('Study Status'), max_length=30)
	comment = models.CharField(_('Comment'), max_length=50, blank=True)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Study Status')
		verbose_name_plural = _('Study Status')	
	
class Study(models.Model):
	patient = models.ForeignKey(Patient, verbose_name=_('Patient'))
	accnum = models.CharField(_('Accnum'), max_length=20)
	study_date = models.DateTimeField(_('Study Date'))
	department = models.ForeignKey(Department, verbose_name=_('Department'))
	clinician = models.ForeignKey(Clinician, verbose_name=_('Clinician'))
	region = models.ForeignKey(Region, verbose_name=_('Region'))
	mode = models.ForeignKey(Mode, verbose_name=_('Mode'))
	exam_room = models.ForeignKey(ExamRoom, verbose_name=_('Exam Room'))
	device = models.ForeignKey(Device, verbose_name=_('Device'))
	study_status = models.ForeignKey(StudyStatus, verbose_name=_('Study Status'))

	def __unicode__(self):
		return self.accnum
		
	class Meta:
		verbose_name = _('Study')
		verbose_name_plural = _('Study')
		

