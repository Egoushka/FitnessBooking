import { VisitType } from '../../../model/enums/visitType.enum.';
import { SectionService } from '../../../shared/service/section.service';
import { LogService } from '../../../shared/service/log.service';
import { CoachService } from '../../../shared/service/coach.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({ templateUrl: 'add-edit-section.component.html' })
export class AddEditSectionComponent implements OnInit {
  form: FormGroup;
  id: number;
  name: string;
  type: string;
  gymId: number;
  isAddMode: boolean;
  loading: boolean = false;
  submitted: boolean = false;

  visitTypes: Array<string> = [];
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private sectionService: SectionService
  ) {}

  ngOnInit(): void {
    for (let value in VisitType)
      if (typeof VisitType[value] === 'number') this.visitTypes.push(value);

    this.id = +history.state.sectionId;
    this.gymId = +sessionStorage.getItem('gymId');
    this.isAddMode = !this.id;

    if (!this.isAddMode) {
      this.name = history.state.name;
      this.type = VisitType[history.state.typeId];
    }

    this.form = this.formBuilder.group({
      name: [this.isAddMode ? '' : this.name, Validators.required],
      type: [
        this.visitTypes[0],
        this.isAddMode ? Validators.required : Validators.nullValidator,
      ],
    });
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    if (this.isAddMode) {
      this.createSection();
    } else {
      this.updateSection();
    }
  }

  private createSection(): void {
    this.sectionService
      .add(this.f.name.value, +VisitType[this.f.type.value], this.gymId)
      .subscribe((result) => {
        this.exit();
      });
  }

  private updateSection(): void {
    this.sectionService
      .update(+this.id, this.f.name.value, +VisitType[this.f.type.value], this.gymId)
      .subscribe((result) => {
        this.exit();
      });
  }
  private exit(){
    this.router.navigate(['sections']);
  }
}
