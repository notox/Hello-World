from django.http import HttpResponseRedirect, HttpResponse
from django.template import RequestContext, loader
from django.core.urlresolvers import reverse
from django.shortcuts import get_object_or_404, render, render_to_response
from django.views import generic
from django import forms
from django.utils.translation import ugettext_lazy as _
from django.forms import DateInput

from ris.models import Study, Department, VisitType, Patient

class RegisterForm(forms.Form):
	name = forms.CharField(label=_('Name'), max_length=32)
	birthday = forms.DateTimeField(label=_('Birthday'))
	accnum = forms.CharField(label=_('Accnum'),max_length=20)
	study_date = forms.DateTimeField(label=_('Study Date'))
	department = forms.ModelChoiceField(Department.objects.order_by('-id'), label=_('Department'))
	visittype = forms.ModelChoiceField(VisitType.objects.order_by('-id'), label=_('VisitType'))

def index(request):
	latest_study_list = Study.objects.order_by('-pk')[:5]
	
	departments = Department.objects.order_by('-id')
	visittypes = VisitType.objects.order_by('-id')
	
	context = {'latest_study_list': latest_study_list, 'departments': departments, 'visittypes':visittypes}
	return render(request, 'ris/study/index.html', context)
	
def register(request):
	department = get_object_or_404(Department, pk=request.POST['department'])
	visittype = get_object_or_404(VisitType, pk=request.POST['visittype'])
	patient = Patient(name=request.POST['name'], birthday=request.POST['birthday'])
	patient.save()
	
	study = Study(accnum=request.POST['accnum'], study_date=request.POST['study_date'], patient=patient, visitType=visittype, department=department)
	study.save()
	return HttpResponseRedirect(reverse('ris:study_index'))
	
def register_form(request):
	latest_study_list = Study.objects.order_by('-pk')[:5]
	
	if request.method == 'POST':
		form = RegisterForm(request.POST)
		if form.is_valid():
			department = form.cleaned_data['department']
			visittype = form.cleaned_data['visittype']
		
			patient = Patient(name=form.cleaned_data['name'], birthday=form.cleaned_data['birthday'])
			patient.save()
	
			study = Study(accnum=form.cleaned_data['accnum'], study_date=form.cleaned_data['study_date'], patient=patient, visitType=visittype, department=department)
			study.save()
			return HttpResponseRedirect(reverse('ris:study_register_form'))
	else:
		form = RegisterForm()
		
	return render(request, 'ris/study/index_form.html', {
		'form': form, 'latest_study_list': latest_study_list
	})
	
def register_form_update(request):
	latest_study_list = Study.objects.order_by('-pk')[:5]
	
	'''study = get_object_or_404(Study, pk=study_id)
	form = RegisterForm({'name':study.patient.name, 'birthday':study.patient.birthday, 'accnum':study.accnum, 'study_date':study.study_date, 'department':study.department, 'visittype':study.visitType})'''
	form = RegisterForm()	
	
	return render(request, 'ris/study/index_form_update.html', {
		'form': form, 'latest_study_list': latest_study_list
	})
	
def detail(request, study_id):
	return HttpResponse("study id %s" % study_id)
	
class IndexView(generic.ListView):
	context_object_name = 'latest_study_list'
	template_name = 'ris/study/study_list.html'
	
	def get_queryset(self):
		return Study.objects.order_by('-pk')[:5]
		
	