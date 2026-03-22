# BookStore Pro (Day 40)

A high-quality Angular 19 application demonstration advanced concepts like Observables, HTTP Interceptors, custom Pipes, and Parent-Child component communication.

## 🚀 Key Features
- **Advanced Observables**: Implements both manual subscription (with `ngOnDestroy` cleanup) and the `async` pipe.
- **HTTP Interceptor**: `AuthInterceptor` automatically adds a Bearer token to all outgoing requests.
- **Data Persistence**: Uses a local mock JSON (`src/assets/books.json`) with `HttpClient`.
- **Data Transformation**:
  - **Built-in Pipes**: `UpperCasePipe`, `CurrencyPipe` (INR), `DatePipe`, `SlicePipe`.
  - **Custom Pipe**: `DiscountPipe` for dynamic price calculation.
- **Component Architecture**: Clean Parent (`Books`) to Child (`BookItem`) data flow using `@Input()`.
- **Modern UI**: Built with a responsive CSS grid and Inter typography.

## 📁 Project Structure
```text
Day 40/bookstore-pro/
├── src/
│   ├── app/
│   │   ├── components/
│   │   │   ├── books/         # Parent Component
│   │   │   └── book-item/     # Child Component
│   │   ├── services/
│   │   │   └── data.service.ts # Data fetching logic
│   │   ├── interceptors/
│   │   │   └── auth.interceptor.ts # Request header modification
│   │   ├── pipes/
│   │   │   └── discount.pipe.ts # Custom transformation
│   │   ├── app-module.ts      # Main App Module
│   │   └── app.ts             # Root Component
│   └── assets/
│       └── books.json         # Mock database
```

## 🛠️ Setup & Run

1. **Navigate to the project:**
   ```bash
   cd "Day 40/bookstore-pro"
   ```

2. **Install dependencies:**
   ```bash
   npm install
   ```

3. **Start the development server:**
   ```bash
   npm start
   ```
   Open [http://localhost:4200](http://localhost:4200) in your browser.

## 🧠 Concepts Demonstrated

### 1. HTTP Interceptor
The `AuthInterceptor` intercepts all `HttpClient` calls and appends:
`Authorization: Bearer dummy-token`

### 2. Observable Consumption
- **Manual**: Subscribed in `ngOnInit` and unsubscribed in `ngOnDestroy` to prevent memory leaks.
- **Async Pipe**: Directly used in the template (`books$ | async`), which automatically handles subscription/unsubscription.

### 3. Custom Pipe
The `discount` pipe takes a percentage parameter and calculates the reduced price:
`{{ price | discount:15 | currency:'INR' }}`
