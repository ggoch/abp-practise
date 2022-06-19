import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto, validateUrl } from '@abp/ng.core';
import { BookService, BookDto, bookTypeOptions } from '@proxy/books';
import { query } from '@angular/animations';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService,Confirmation } from '@abp/ng.theme.shared';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class BookComponent implements OnInit {
  book = { item: [], totalCount: 0 } as PagedResultDto<BookDto>;

  selelctedBook = {} as BookDto;

  form: FormGroup;

  bookTypes = bookTypeOptions;

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private bookService: BookService,
    private fb: FormBuilder,
    private confirmation:ConfirmationService
  ) {}

  ngOnInit(): void {
    const bookStreamCreator = query => this.bookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe(response => {
      this.book = response;
    });
  }

  createBook() {
    this.selelctedBook = {} as BookDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editBook(id: string) {
    this.bookService.get(id).subscribe(book => {
      this.selelctedBook = book;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id:string){
    this.confirmation.warn('::AreYouSureToDlelte','::AreYouSure').subscribe((status)=>{
      if(status == Confirmation.Status.confirm){
        this.bookService.delete(id).subscribe(()=>this.list.get());
      }
    })
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selelctedBook.name || '', Validators.required],
      type: [this.selelctedBook.type || null, Validators.required],
      publishDate: [
        this.selelctedBook.publishDate ? new Date(this.selelctedBook.publishDate) : null,
        Validators.required,
      ],
      price: [this.selelctedBook.price || null, Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selelctedBook.id
      ? this.bookService.update(this.selelctedBook.id, this.form.value)
      : this.bookService.create(this.form.value);

    request.subscribe(()=>{
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    })  
  }
}
