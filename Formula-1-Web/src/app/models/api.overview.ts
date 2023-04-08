import { Endpoint } from './endpoint';

export interface ApiOverview {
    name: string;
    description: string;
    version: string;
    source: string;
    endpoints: Array<Endpoint>
}