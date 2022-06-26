import type { BookUserDto, CreateUpdateBookUserDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookUserService {
  apiName = 'Default';

  create = (input: CreateUpdateBookUserDto) =>
    this.restService.request<any, BookUserDto>({
      method: 'POST',
      url: '/api/app/book-user',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book-user/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, BookUserDto>({
      method: 'GET',
      url: `/api/app/book-user/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<BookUserDto>>({
      method: 'GET',
      url: '/api/app/book-user',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateBookUserDto) =>
    this.restService.request<any, BookUserDto>({
      method: 'PUT',
      url: `/api/app/book-user/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
