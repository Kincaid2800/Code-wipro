import { Component, EventEmitter, Output } from '@angular/core';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.css',
  standalone: false
})
export class CourseListComponent {
  courses: Course[] = [
    { id: 1, title: 'Web Development', duration: '8 weeks' },
    { id: 2, title: 'Data Science', duration: '12 weeks' },
    { id: 3, title: 'Mobile App Development', duration: '10 weeks' }
  ];

  @Output() courseSelected = new EventEmitter<Course>();

  selectCourse(course: Course): void {
    this.courseSelected.emit(course);
  }
}
