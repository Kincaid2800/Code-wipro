import { Component, Input } from '@angular/core';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.css',
  standalone: false
})
export class CourseDetailComponent {
  @Input() course: Course | null = null;
}
