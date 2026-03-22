# Event Manager Portal (Day 35)

## Project Overview
The Event Manager Portal is a comprehensive Angular application designed to manage and display a list of events. This project serves as a demonstration of advanced Angular features including custom pipes for data transformation, custom directives for DOM manipulation, and the Angular Animations module for an enhanced user experience.

## Features
- **Event Dashboard**: Displays a visually appealing grid of events using `*ngFor`.
- **Custom Currency Formatting**: Uses a `PriceFormatPipe` to transform raw numbers into formatted Indian Rupee (₹) currency strings with two decimal places.
- **Premium Event Highlighting**: Implements a `HighlightDirective` that automatically applies a light gold background and bold text to any event priced over ₹2,000.
- **Micro-Animations**: Features a entry fade-in/slide-up animation for the event list and subtle hover transitions for individual event cards.
- **Responsive Design**: Clean and readable UI that adapts to different screen sizes.

## Angular Concepts Demonstrated
1. **Custom Pipe (`PriceFormatPipe`)**:
   - Location: `src/app/pipes/price-format.pipe.ts`
   - Use case: Formatting `price` property to `₹X,XXX.00`.
2. **Custom Directive (`HighlightDirective`)**:
   - Location: `src/app/directives/highlight.directive.ts`
   - Use case: Conditional styling based on event price.
3. **Angular Animations**:
   - Implementation: `trigger`, `transition`, `animate` in `EventListComponent`.
   - Effect: Fade-in and vertical slide on component initialization.
4. **Standalone: false**:
   - All components, pipes, and directives are configured as non-standalone to demonstrate traditional `AppModule` based architecture.

## Folder Structure
- `src/app/components/event-list/`: Main UI logic and templates.
- `src/app/pipes/`: Custom data transformation logic.
- `src/app/directives/`: Custom behavior/style extensions.
- `src/app/models/`: Centralized interfaces.
- `src/app/app.module.ts`: Central hub for declarations and imports (including `BrowserAnimationsModule`).

## How to Run the Project
1. **Navigate to the project folder:**
   ```bash
   cd "Day 35/event-manager-app"
   ```
2. **Install dependencies:**
   ```bash
   npm install
   ```
3. **Run the development server:**
   ```bash
   ng serve
   ```
4. **Access the application:** Open `http://localhost:4200` in your browser.

## Tools Used
- **Angular CLI**: Project management.
- **BrowserAnimationsModule**: To enable powerful CSS-based animations.
- **TypeScript**: Ensuring robust type-safety for event data.
