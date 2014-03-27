from django.db import models
from django.utils.translation import ugettext_lazy as _

from hospital.models import Department, Clinician, Region
from radiology.models import Mode, ExamRoom, Device

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
		

