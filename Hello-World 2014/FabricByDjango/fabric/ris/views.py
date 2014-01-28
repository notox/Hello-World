from django.http import HttpResponseRedirect, HttpResponse
from django.template import RequestContext, loader
from django.core.urlresolvers import reverse
from django.shortcuts import render
from django.views import generic
from django.views.generic.base import View
from django import forms
from django.utils.translation import ugettext_lazy as _

from django.contrib.auth.decorators import login_required
from django.utils.decorators import method_decorator

from ris.models import Study, Department, VisitType, Patient

class RegisterForm(forms.Form):
	name = forms.CharField(label=_('Name'), max_length=32)
	birthday = forms.DateTimeField(label=_('Birthday'))
	accnum = forms.CharField(label=_('Accnum'),max_length=20)
	study_date = forms.DateTimeField(label=_('Study Date'))
	department = forms.ModelChoiceField(Department.objects.order_by('-id'), label=_('Department'))
	visittype = forms.ModelChoiceField(VisitType.objects.order_by('-id'), label=_('VisitType'))
	
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
			visittype = form.cleaned_data['visittype']
		
			patient = Patient(name=form.cleaned_data['name'], birthday=form.cleaned_data['birthday'])
			patient.save()
	
			study = Study(accnum=form.cleaned_data['accnum'], study_date=form.cleaned_data['study_date'], patient=patient, visitType=visittype, department=department)
			study.save()
			return HttpResponseRedirect(reverse('ris:register'))
		
		return render(request, self.template_name, {
			'form': form, 'latest_study_list': latest_study_list
		})

def detail(request, study_id):
	return HttpResponse("study id %s" % study_id)	
	