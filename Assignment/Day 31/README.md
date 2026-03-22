# EduLearn Course Management SPA

## Project Overview
EduLearn is a Single Page Application (SPA) built with Angular that allows users to manage a list of courses. The application demonstrates core Angular concepts, specifically focusing on different types of data binding and modular component architecture.

## Features
- **Course List**: Displays a dynamic list of available courses with their titles and durations.
- **Course Details**: Shows detailed information for a selected course.
- **Live Editing**: Allows real-time editing of course titles with immediate updates across the UI.
- **Modular Design**: Separated concerns into `CourseListComponent`, `CourseDetailComponent`, and a centralized `AppComponent`.

## Angular Binding Techniques Demonstrated
1. **Property Binding (`[property]="value"`)**:
   - Used to pass the `selectedCourse` from the parent `AppComponent` down to the child `CourseDetailComponent`.
2. **Event Binding (`(event)="handler($event)"`)**:
   - Used in `CourseListComponent` to notify the parent `AppComponent` when a user clicks the "View Details" button.
3. **Two-Way Binding (`[(ngModel)]="property"`)**:
   - Used in `CourseDetailComponent` to sync the input field with the course title, providing real-time UI updates.

## Folder Structure
- `src/app/components/course-list/`: Component for displaying the course lineup.
- `src/app/components/course-detail/`: Component for viewing and editing course details.
- `src/app/models/`: Contains the `Course` interface definition.
- `src/app/app.module.ts`: Root module where components and `FormsModule` are configured.

## How to Run the Project
1. **Navigate to the project folder:**
   ```bash
   cd "Day 31/edulearn-app"
   ```
2. **Install dependencies:**
   ```bash
   npm install
   ```
3. **Run the development server:**
   ```bash
   ng serve
   ```
4. **Access the application:** Open your browser and navigate to `http://localhost:4200`.

## Tools Used
- **Angular CLI**: Project scaffold and generation.
- **TypeScript**: Typed logic and models.
- **CSS**: Clean and simple layout styling.
