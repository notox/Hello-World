from django.db import models
from django.utils.translation import ugettext_lazy as _

class Department(models.Model):
	name = models.CharField(max_length=30)
	comment = models.CharField(max_length=50)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Department')
		verbose_name_plural = _('Department')

class VisitType(models.Model):
	name = models.CharField(max_length=30)
	comment = models.CharField(max_length=50)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('VisitType')
		verbose_name_plural = _('VisitType')
		
class Clinician(models.Model):
	name = models.CharField(max_length=30)
	department = models.ForeignKey(Department)
	
	def __unicode__(self):
		return self.name
		
	class Meta:
		verbose_name = _('Clinician')
		verbose_name_plural = _('Clinician')

class Patient(models.Model):
	name = models.CharField(_('Name'), max_length=32)
	birthday = models.DateTimeField(_('Birthday'), 'birthday')
	
	def __unicode__(self):
		return self.name
	
	class Meta:
		verbose_name = _('Patient')
		verbose_name_plural = _('Patient')
	
class Study(models.Model):
	patient = models.ForeignKey(Patient, verbose_name=_('Patient'))
	accnum = models.CharField(_('Accnum'), max_length=20)
	study_date = models.DateTimeField(_('Study Date'))
	department = models.ForeignKey(Department, verbose_name=_('Department'))
	visitType = models.ForeignKey(VisitType, verbose_name=_('VisitType'))

	def __unicode__(self):
		return self.accnum
		
	class Meta:
		verbose_name = _('Study')
		verbose_name_plural = _('Study')
		

