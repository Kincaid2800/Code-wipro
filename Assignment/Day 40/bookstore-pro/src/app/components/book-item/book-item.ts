import { Component, Input } from '@angular/core';
import { Book } from '../../services/data-service';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.html',
  styleUrls: ['./book-item.css'],
  standalone: false
})
export class BookItem {
  @Input() book!: Book;
}
