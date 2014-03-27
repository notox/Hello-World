from django.http import HttpResponseRedirect, HttpResponse
from django.template import RequestContext, loader
from django.core.urlresolvers import reverse
from django.shortcuts import render
from django.views import generic
from django.views.generic.base import View
from django.forms.widgets import HiddenInput
from django import forms
from django.utils.translation import ugettext_lazy as _

from django.contrib.auth.decorators import login_required
from django.utils.decorators import method_decorator

from ris.models import Study, Patient
from hospital.models import Department, VisitType, Clinician

class RegisterForm(forms.Form):
	pk = forms.IntegerField(required=False, widget=HiddenInput)
	name = forms.CharField(label=_('Name'), max_length=32)
	birthday = forms.DateTimeField(label=_('Birthday'))
	accnum = forms.CharField(label=_('Accnum'),max_length=20)
	study_date = forms.DateTimeField(label=_('Study Date'))
	department = forms.ModelChoiceField(Department.objects.order_by('-id'), label=_('Department'))
	visit_type = forms.ModelChoiceField(VisitType.objects.order_by('-id'), label=_('Visit Type'))
	clinician = forms.ModelChoiceField(Clinician.objects.order_by('-id'), label=_('Clinician'))
	
class RegisterFormView(View):
	form_class = RegisterForm
	template_name = 'ris/register.html'		
	
	@method_decorator(login_required)
	def dispatch(self, *args, **kwargs):
		return super(RegisterFormView, self).dispatch(*args, **kwargs)
		
	def get(self, request, *args, **kwargs):
		form = self.form_class()
		latest_study_list = Study.objects.order_by('-pk')[:5]
		return render(request, self.template_name, {
			'form': form, 'latest_study_list': latest_study_list
		})
	
	def post(self, request, *args, **kwargs):
		form = self.form_class(request.POST)
		latest_study_list = Study.objects.order_by('-pk')[:5]
		if form.is_valid():
			department = form.cleaned_data['department']
			visit_type = form.cleaned_data['visit_type']
		
			patient = Patient(name=form.cleaned_data['name'], birthday=form.cleaned_data['birthday'])
			patient.save()
	
			study = Study(accnum=form.cleaned_data['accnum'], study_date=form.cleaned_data['study_date'], patient=patient, visit_type=visit_type, department=department)
			study.save()
			return HttpResponseRedirect(reverse('ris:register'))
		
		return render(request, self.template_name, {
			'form': form, 'latest_study_list': latest_study_list
		})

class RegisterFormUpdateView(View):
	form_class = RegisterForm
	template_name = 'ris/update_register.html'		
	
	@method_decorator(login_required)
	def dispatch(self, *args, **kwargs):
		return super(RegisterFormUpdateView, self).dispatch(*args, **kwargs)
		
	def get(self, request, *args, **kwargs):
		study = Study.objects.get(pk=kwargs['study_id'])
		form = self.form_class({
			'pk':study.pk,
			'name':study.patient.name,
			'birthday':study.patient.birthday,
			'accnum':study.accnum,
			'study_date':study.study_date,
			'visit_type':study.visit_type.pk,
			'department':study.department.pk
		})
		latest_study_list = Study.objects.order_by('-pk')[:5]
		return render(request, self.template_name, {
			'form': form, 'latest_study_list': latest_study_list
		})
	
	def post(self, request, *args, **kwargs):
		form = self.form_class(request.POST)
		latest_study_list = Study.objects.order_by('-pk')[:5]
		if form.is_valid():
			department = form.cleaned_data['department']
			visit_type = form.cleaned_data['visit_type']
	
			study_id = form.cleaned_data['pk']
			study = Study.objects.get(pk=study_id)			
			patient = study.patient
			patient.name=form.cleaned_data['name']
			patient.birthday=form.cleaned_data['birthday']
			patient.save()
			
			study.accnum=form.cleaned_data['accnum']
			study.study_date=form.cleaned_data['study_date']			
			study.visit_type=visit_type
			study.department=department
			study.save()
			
			return HttpResponseRedirect(reverse('ris:register'))
		
		return render(request, self.template_name, {
			'form': form, 'latest_study_list': latest_study_list
		})

def detail(request, study_id):
	return HttpResponse("study id %s" % study_id)	
	