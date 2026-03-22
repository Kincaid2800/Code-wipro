import { Component } from '@angular/core';
import { Course } from './models/course.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: false
})
export class AppComponent {
  selectedCourse: Course | null = null;

  onCourseSelected(course: Course): void {
    this.selectedCourse = course;
  }
}
