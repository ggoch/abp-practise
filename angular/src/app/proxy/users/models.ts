import type { EntityDto } from '@abp/ng.core';

export interface BookUserDto extends EntityDto<string> {
  tenantId?: string;
  userName?: string;
  name?: string;
  surname?: string;
}

export interface CreateUpdateBookUserDto {
  name: string;
  userName: string;
  surname: string;
}
