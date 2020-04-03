import { Relation } from './relation';

export interface GetRelationResponse {
    totalCount: number;
    items: Relation[];
}