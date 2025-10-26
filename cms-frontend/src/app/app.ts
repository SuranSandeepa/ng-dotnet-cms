// import { Component, signal } from '@angular/core';
// import { MatButtonModule } from '@angular/material/button';
// import { MatCardModule } from '@angular/material/card';

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [
//     MatButtonModule,
//     MatCardModule, // <--- ADDED HERE
//   ],
//   templateUrl: './app.html',
//   styleUrl: './app.css',
// })
// export class App {
//   protected readonly title = signal('Blog Application');
// }

import { Component, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

// Define the shape of the Category data we expect from the API
interface Category {
  id: number;
  name: string;
}
// Define the shape of the Tag data we expect from the API
interface Tag {
  id: number;
  name: string;
}

@Component({
  selector: 'app-root',
  // Imports all necessary modules (Material, HTTP, and CommonModule for *ngFor)
  imports: [MatButtonModule, MatToolbarModule, MatCardModule, HttpClientModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: true,
})
export class App implements OnInit {
  protected readonly title = signal('Blog Application');

  // Signal to hold the list of categories fetched from the backend
  protected categoryList = signal<Category[]>([]);
  // Signal to hold the list of tags fetched from the backend
  protected tagList = signal<Tag[]>([]);

  // Inject the HttpClient service (needed for API calls)
  constructor(private http: HttpClient) {}

  // Calls the fetch function immediately when the component loads
  ngOnInit(): void {
    this.fetchCategories(); //call the category function
    this.fetchTags(); //call the tag function
  }

  fetchCategories() {
    // The URL of your .NET API Category endpoint
    const apiUrl = 'https://localhost:7106/api/Category';

    // Make the API call and subscribe to the results
    this.http.get<Category[]>(apiUrl).subscribe({
      next: (data) => {
        // Update the signal with the fetched data
        this.categoryList.set(data);
        console.log('Categories loaded:', data);
      },
      error: (err) => {
        console.error('Failed to fetch categories. Check API and CORS settings.', err);
      },
    });
  }

  fetchTags() {
    // The URL of your .NET API Tag endpoint
    const apiUrl = 'https://localhost:7106/api/Tag';

    // Make the API call and subscribe to the results
    this.http.get<Tag[]>(apiUrl).subscribe({
      next: (data) => {
        // Update the new signal with the fetched data
        this.tagList.set(data);
        console.log('Tags loaded:', data);
      },
      error: (err) => {
        console.error('Failed to fetch tags. Check API and CORS settings.', err);
      },
    });
  }
}
