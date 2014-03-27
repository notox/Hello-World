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
