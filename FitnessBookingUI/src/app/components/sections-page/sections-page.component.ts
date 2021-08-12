import { LogService } from './../../shared/service/log.service';
import { SectionService } from './../../shared/service/section.service';
import { Section } from './../../model/section/section.model';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sections-page',
  templateUrl: './sections-page.component.html'
})
export class SectionsPageComponent implements OnInit {
  public sections$: Section[];
  private gymId:number;
  constructor(
    private router: Router,
    private sectionService: SectionService,
    public authService: AuthService,
    private logger: LogService
  ){}

  ngOnInit(): void {
    this.gymId = +sessionStorage.getItem('gymId')
    this.sectionService.get(null, null, this.gymId, null).subscribe(values=>{
      this.sections$ = values;
    })
  }
  deleteSection(sectionId:number){
    this.logger.log("Section deleted")
  }
  addSection(){
    sessionStorage.setItem('gymId', this.gymId.toString());
    this.router.navigate([`add-edit-section-page`]);
  }
  editSection( sectionId: number,typeId: number, name: string){
    this.router.navigate([`add-edit-section-page`], {state:{
      sectionId: sectionId,
      typeId: typeId,
      name: name
    }});
  }
  viewSchedules(sectionId:number){
    sessionStorage.setItem('sectionId', sectionId.toString());
    this.router.navigate([`section-schedules-page`]);
  }
  addCoach(){
    this.router.navigate(['add-edit-coach-page'])
  }
}
