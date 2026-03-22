import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { DataService, Book } from '../../services/data-service';

@Component({
  selector: 'app-books',
  templateUrl: './books.html',
  styleUrls: ['./books.css'],
  standalone: false
})
export class Books implements OnInit, OnDestroy {
  // Approach 1: Async Pipe
  books$: Observable<Book[]>;

  // Approach 2: Manual Subscription
  manualBooks: Book[] = [];
  private subscription: Subscription = new Subscription();

  constructor(private dataService: DataService) {
    this.books$ = this.dataService.getBooks();
  }

  ngOnInit(): void {
    console.log('[BOOKS] Initializing data fetching approaches...');
    
    // Demonstrate manual subscription
    this.subscription.add(
      this.dataService.getBooks().subscribe({
        next: (data) => {
          console.log('[BOOKS] Manual subscription received data');
          this.manualBooks = data;
        },
        error: (err) => console.error('[BOOKS] Error in manual subscription:', err)
      })
    );
  }

  ngOnDestroy(): void {
    console.log('[BOOKS] Unsubscribing from manual subscription to prevent memory leaks');
    this.subscription.unsubscribe();
  }
}
